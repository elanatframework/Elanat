namespace Elanat.DataUse
{
    public class Rating
    {
        public void Set(string ContentId, string Rate)
        {
            DataBaseSocket db = new DataBaseSocket();
            db.SetProcedure("set_content_rating", new List<string>() { "@content_id", "@content_rate" }, new List<string>() { ContentId, Rate });
        }
    }
}