using Newtonsoft.Json;
using System;

namespace Almotkaml
{
    public static class TryConvert
    {
        public static bool ToDate(string dateString, out DateTime date) => DateTime.TryParse(dateString, out date);

        public static bool ToDeserializedObject<TObject>(string serializedObject, out TObject obj)
        {
            try
            {
                obj = JsonConvert.DeserializeObject<TObject>(serializedObject);
                return obj != null;
            }
            catch
            {
                // ignored
            }
            obj = default(TObject);
            return false;
        }
    }
}
