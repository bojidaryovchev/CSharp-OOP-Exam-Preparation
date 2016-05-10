using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class Griffin : Creature
    {
        private const int DefaultGriffinAttack = 8;
        private const int DefaultGriffinDefense = 8;
        private const int DefaultGriffinHealth = 25;
        private const decimal DefaultGriffinDamage = 4.5m;
        private const int GriffinDoubleDefenseWhenDefendingBonusRoundsCount = 5;
        private const int GriffinAddDefenseWhenSkipBonus = 3;

        public Griffin() : base(DefaultGriffinAttack, DefaultGriffinDefense, DefaultGriffinHealth, DefaultGriffinDamage)
        {
            this.AddSpecialty(new DoubleDefenseWhenDefending(GriffinDoubleDefenseWhenDefendingBonusRoundsCount));
            this.AddSpecialty(new AddDefenseWhenSkip(GriffinAddDefenseWhenSkipBonus));
            this.AddSpecialty(new Hate(typeof (WolfRaider)));
        }
    }
}