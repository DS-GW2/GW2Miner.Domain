using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GW2Miner.Domain
{
    public class BoolConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((bool)value) ? 1 : 0);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return reader.Value.ToString() == "1";
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(bool);
        }
    }

    public class JsonFlagsEnumTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            Type t = (ReflectionUtils.IsNullableType(objectType))
              ? Nullable.GetUnderlyingType(objectType)
              : objectType;

            return t.IsEnum && Attribute.IsDefined(t, typeof(FlagsAttribute));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        private object ToEnum(string str, Type enumType)
        {
            foreach (var name in Enum.GetNames(enumType))
            {
                EnumMemberAttribute[] enumAttr = ((EnumMemberAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true));
                if (enumAttr.Length == 0) continue; // Not an EnumMember
                var enumMemberAttribute = enumAttr.Single();
                if (String.Compare(enumMemberAttribute.Value, str, true) == 0) return Enum.Parse(enumType, name, true);
            }

            return Enum.Parse(enumType, str, true);
            //throw new Exception(string.Format("UnExpected enumeration string {0}.", str));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Type t = (ReflectionUtils.IsNullableType(objectType))
                        ? Nullable.GetUnderlyingType(objectType)
                        : objectType;

            if (reader.TokenType == JsonToken.Null)
            {
                if (!ReflectionUtils.IsNullableType(objectType))
                    throw new Exception(string.Format("Cannot convert null value to {0}.", objectType));

                return null;
            }

            dynamic source = Activator.CreateInstance(t);

            if (reader.TokenType == JsonToken.StartArray)
            {
                reader.Read();
                //var values = new List<object>();
                while (reader.TokenType != JsonToken.EndArray)
                {
                    //values.Add(ToEnum(reader.Value.ToString(), t));
                    dynamic flag = Convert.ChangeType(ToEnum(reader.Value.ToString(), t), t);
                    source |= flag;
                    reader.Read();
                }

                //foreach (object value in values)
                //{
                //    dynamic flag = Convert.ChangeType(value, t);
                //    source |= flag;
                //}

                return source;
            }

            throw new Exception(string.Format("Unexpected token when parsing enum. Expected Array, got {0}.", reader.TokenType));
        }
    }
}
