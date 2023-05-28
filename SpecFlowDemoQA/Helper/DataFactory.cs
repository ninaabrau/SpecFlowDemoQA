using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SpecFlowDemoQA.Variables;

namespace SpecFlowDemoQA.Helper
{
    public class DataFactory
    {
        public static User GetUserData()
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            var jsonpath = dir.Replace("bin\\Debug\\net6.0", "Data\\user.json").TrimEnd('\\');
            string jsonString = File.ReadAllText(jsonpath);
            return JsonConvert.DeserializeObject<User>(jsonString)!;

        }
    }
}