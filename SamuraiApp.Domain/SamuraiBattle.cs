using System;
namespace SamuraiApp.Domain
{
    public class SamuraiBattle // This is the "join entity" class which joins the Samurai class to the Battle class
    {
        public int SamuraiId { get; set; }
        public int BattleId { get; set; }
        public Samurai Samurai { get; set; }
        public Battle Battle { get; set; }
    }
}
