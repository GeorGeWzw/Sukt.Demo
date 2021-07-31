using NBomber.Contracts;
using NBomber.CSharp;
using NBomber.Plugins.Http.CSharp;
using NBomber.Plugins.Network.Ping;
using Newtonsoft.Json;
using System;

namespace Sukt.NBomber
{
    class Program
    {
        static void Main(string[] args)
        {

            var httpFactory = HttpClientFactory.Create();
            var getUser = Step.Create("get_menu",
                                      clientFactory: httpFactory,
                                      execute: async context =>
                                      {
                                          var url = $"https://api.destinycore.club/api/Menu/GetVueDynamicRouterTreeAsync";
                                          var request = Http.CreateRequest("GET", url).WithHeader("authorization", "Bearer eyJhbGciOiJSUzI1NiIsImtpZCI6IjA2NkNDRDJFMzIzQUZENzI5Mzk0RTJGNzEyRTVERkQyIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE2Mjc2NTIwODYsImV4cCI6MTYyNzY1NTY4NiwiaXNzIjoiaHR0cHM6Ly9hdXRoLmRlc3Rpbnljb3JlLmNsdWIiLCJhdWQiOiJEZXN0aW55LkNvcmUuRmxvdy5BUEkiLCJjbGllbnRfaWQiOiJEZXN0aW55Q29yZUZsb3dSZWFjdENsaWVudCIsInN1YiI6ImExZTg5ZjQ1LTRmYTgtNDc1MS05ZGY5LWRlYzg2ZjdlNmMxNCIsImF1dGhfdGltZSI6MTYyNzY1MjA4NSwiaWRwIjoibG9jYWwiLCJuYW1lIjoiQWRtaW4iLCJuaWtlbmFtZSI6IueuoeeQhuWRmCIsImlzQWRtaW4iOiIxIiwicm9sZWlkIjoiYjg1NTFlOTctMDcyMy00N2ZjLWJkN2UtYWZmMzViYjFiMWU3IiwianRpIjoiMDYxQTMxOTQ0NkVENDUyNkY5MUI5NjVBRTcwQTc3OEYiLCJzaWQiOiI1NjRFN0I3NEQ4NzE2NjdDNzY0NzMyREE2RkIxRTI4NSIsImlhdCI6MTYyNzY1MjA4Niwic2NvcGUiOlsib3BlbmlkIiwicHJvZmlsZSIsInJvbGVzIiwiRGVzdGlueS5Db3JlLkZsb3cuQVBJIl0sImFtciI6WyJwd2QiXX0.KbbYgJ0by5F_h5fDZqsUzQJMMcLAux62Hm9iDmhnonn2u-qVZkFF-0QQdaEJ1VLRKx1Ax8tOdy2_GW9FAz8ICY5KV7uA5cA5yeXZ3oxs9n3ziwwYq3M0qoAg4CdAAsvTRlVRC6LTZ66aG1tBFv68CZTijdpZxHLHQctDum7dPhbemVJmQ8x0Pa7tmejnZLou6ff5jOIwNUUyjRcqFxVhyV64ftyk6FhM_9i9x2I-Y4vsNfgViVyd2uPZQ9dVFvsWNYjTjiV_oGmWqkHuBOtRKEMUKIPGNFOn_KHDcUIK-jY2BMGX0omOzN3CmOVTYO72akOfmdtkMVOxs7iD9vQgbQ")
                                              .WithCheck(async response =>
                                              {
                                                  var json = await response.Content.ReadAsStringAsync();

                        // parse JSON
                        //var menu = JsonConvert.DeserializeObject<dynamic>(json);
                                                  return !string.IsNullOrEmpty(json)
                                                      ? Response.Ok(true) // we pass user object response to the next step
                                                      : Response.Fail($"not found menu");
                                              });
                                          var response = await Http.Send(request, context);
                                          return response;
                                      });
            var scenario = ScenarioBuilder
                .CreateScenario("https://api.destinycore.club/api/Menu/GetVueDynamicRouterTreeAsync:rest_api", getUser)
                .WithWarmUpDuration(TimeSpan.FromSeconds(5))
                .WithLoadSimulations(new[]
                {
                                    Simulation.InjectPerSec(rate: 300, during: TimeSpan.FromSeconds(60))
                });
            var pingPluginConfig = PingPluginConfig.CreateDefault(new[] { "https://api.destinycore.club/api/Menu/GetVueDynamicRouterTreeAsync" });
            var pingPlugin = new PingPlugin(pingPluginConfig);
            NBomberRunner
                .RegisterScenarios(scenario)
                .WithWorkerPlugins(pingPlugin)
                .Run();

        }
    }
}
