namespace app.Domain.Entities
{
    public class HighLight
    {
        public Guid Id {get;set;}
        public string HighLightName {get;set;}

        public Property Property {get;set;}
    }
}