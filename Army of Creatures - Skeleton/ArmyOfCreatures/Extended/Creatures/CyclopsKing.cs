using ArmyOfCreatures.Extended.Specialties;
using ArmyOfCreatures.Logic.Creatures;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class CyclopsKing : Creature
    {
        private const int DefaultCyclopsKingAttack = 17;
        private const int DefaultCyclopsKingDefense = 13;
        private const int DefaultCyclopsKingHealth = 70;
        private const decimal DefaultCyclopsKingDamage = 18;
        private const int CyclopsKingPermanentAttackBonusWhenSkip = 3;
        private const int CyclopsKingDoubleAttackWhenAttackingBonusRoundsCount = 4;
        private const int CyclopsKingDoubleDamageBonusRoundsCount = 1;

        public CyclopsKing()
            : base(
                DefaultCyclopsKingAttack, DefaultCyclopsKingDefense, DefaultCyclopsKingHealth, DefaultCyclopsKingDamage)
        {
            this.AddSpecialty(new AddAttackWhenSkip(CyclopsKingPermanentAttackBonusWhenSkip));
            this.AddSpecialty(new DoubleAttackWhenAttacking(CyclopsKingDoubleAttackWhenAttackingBonusRoundsCount));
            this.AddSpecialty(new DoubleDamage(CyclopsKingDoubleDamageBonusRoundsCount));
        }
    }
}