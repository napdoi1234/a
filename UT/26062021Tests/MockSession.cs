using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace _26062021Tests
{
    public class MockSession : ISession
    {
        Dictionary<string, string> mySession = new Dictionary<string, string>();

        string ISession.Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        bool ISession.IsAvailable
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        IEnumerable<string> ISession.Keys
        {
            get { return mySession.Keys; }
        }

        public Task CommitAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task LoadAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        void ISession.Clear()
        {
            mySession.Clear();
        }

        void ISession.Remove(string key)
        {
            mySession.Remove(key);
        }

        void ISession.Set(string key, byte[] value)
        {
            mySession.Add(key, Encoding.UTF8.GetString(value));
        }

        bool ISession.TryGetValue(string key, out byte[] value)
        {
            if (mySession[key] != null)
            {
                value = Encoding.ASCII.GetBytes(mySession[key]);
                return true;
            }
            else
            {
                value = null;
                return false;
            }
        }
    }
}