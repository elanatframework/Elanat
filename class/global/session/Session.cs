namespace Elanat
{
    public class Session
    {
        private ISession TmpSession;

        public Session()
        {
            TmpSession = new HttpContextAccessor().HttpContext.Session;
        }

        public void SetSessionValue(string key, string value)
        {
            if (value == null)
                value = "";

            TmpSession.SetString(key, value);
        }

        public string GetSessionValue(string key)
        {
            if (key == null)
                return "";

            return TmpSession.GetString(key);
        }

        public void RemoveSessionValue(string key)
        {
            if (string.IsNullOrEmpty(key))
                return;

            TmpSession.Remove(key);
        }

        public string GetSessionId()
        {
            return TmpSession.Id;
        }
    }
}