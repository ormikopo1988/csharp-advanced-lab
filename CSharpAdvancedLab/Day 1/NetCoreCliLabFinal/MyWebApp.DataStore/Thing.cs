using static Newtonsoft.Json.JsonConvert;

namespace MyWebApp.DataStore
{
    public class Thing
    {
        public int Get(int left, int right) =>
            DeserializeObject<int>($"{left + right}");
    }
}