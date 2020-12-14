namespace LisaBot.Modules.Guides
{
    public class Category
    {
        public string Title { get; set; }
        public Guide[] List { get; set; }
        
    }
    public class Guide
    {
        public string Title { get; set; }
        public Info Info { get; set; }
    }

    public class Info
    {
        public string Link { get; set; }
        public string Description { get; set; }
        public bool Premium { get; set; }
        public bool EarlyAccess { get; set; }
    }
}