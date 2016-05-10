using ArmyOfCreatures.Extended.Specialties;
using ArmyOfCreatures.Logic.Creatures;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class WolfRaider : Creature
    {
        private const int DefaultWolfRiderAttack = 8;
        private const int DefaultWolfRiderDefense = 5;
        private const int DefaultWolfRiderHealth = 10;
        private const decimal DefaultWolfRiderDamage = 3.5m;
        private const int WolfRiderDoubleDamageBonusRoundsCount = 7;

        public WolfRaider() : base(DefaultWolfRiderAttack, DefaultWolfRiderDefense, DefaultWolfRiderHealth, DefaultWolfRiderDamage)
        {
            this.AddSpecialty(new DoubleDamage(WolfRiderDoubleDamageBonusRoundsCount));
        }
    }
}