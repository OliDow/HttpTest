using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class Program
    {
        public static int Main(string[] args)
        {
            return Task.Run(async () =>
            {
                HttpConnTest connTest = new HttpConnTest(); 
                var resp = await connTest.Get((args.Length > 0) ? args[0] : "http://shatteredsun.com");
                Console.WriteLine(resp);
                return 0;
            }).Result;
        }
    }

    public class HttpConnTest{
        public async Task<string> Get(string url){
            try{
                HttpClient client = new HttpClient();
                var responce = await client.GetStringAsync(url);
                return responce;
            } catch(Exception e){
                return e.Message;
            }
        }
    }
}
