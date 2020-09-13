using VirtualShop.Models;
using Newtonsoft.Json;

namespace VirtualShop.Libraries.Login
{
    public class LoginClient
    {
        private Session.Session _session;
        private string Key = "Login.Client";

        public LoginClient(Session.Session session)
        {
            _session = session;
        }

        public void Login(Client client) 
        {
            string clientJson = JsonConvert.SerializeObject(client);

            _session.Create(Key, clientJson);
        }

        public Client GetClient() 
        {
            string clientJson = _session.Read(Key);
            
            return JsonConvert.DeserializeObject<Client>(clientJson);
        }

        public void Logout()
        {
            _session.RemoveAll();
        }
    }
}
