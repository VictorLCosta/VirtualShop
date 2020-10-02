using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualShop.Models;
using Newtonsoft.Json;

namespace VirtualShop.Libraries.Login
{
    public class CollaboratorLogin
    {
        private string Key = "Login.Collaborator";
        private Session.Session _session;

        public CollaboratorLogin(Session.Session session)
        {
            _session = session;
        }

        public void Login(Collaborator collaborator)
        {
            string collaboratorJson = JsonConvert.SerializeObject(collaborator);

            _session.Create(Key, collaboratorJson);
        }

        public Collaborator GetCollaborator()
        {
            if (_session.Exists(Key))
            {
                string collaboratorJson = _session.Read(Key);

                return JsonConvert.DeserializeObject<Collaborator>(collaboratorJson);
            }
            else
            {
                return null;
            }
        }

        public void Logout()
        {
            _session.RemoveAll();
        }
    }
}
