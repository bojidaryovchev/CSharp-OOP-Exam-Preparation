using System;
using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Specialties;

namespace ArmyOfCreatures.Extended.Specialties
{
    public class AddAttackWhenSkip : Specialty
    {
        private int permanentAttackBonus;

        public AddAttackWhenSkip(int permanentAttackBonus)
        {
            this.PermanentAttackBonus = permanentAttackBonus;
        }

        public int PermanentAttackBonus
        {
            get
            {
                return this.permanentAttackBonus;
            }
            private set
            {
                if (value <= 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException("value", "Attack bonus must be [1...10]");
                }

                this.permanentAttackBonus = value;
            }
        }

        public override void ApplyWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender)
        {
        }

        public override void ApplyWhenDefending(ICreaturesInBattle defenderWithSpecialty, ICreaturesInBattle attacker)
        {
        }

        public override void ApplyAfterDefending(ICreaturesInBattle defenderWithSpecialty)
        {
        }

        public override void ApplyOnSkip(ICreaturesInBattle skipCreature)
        {
            if (skipCreature == null)
            {
                throw new ArgumentNullException("skipCreature");
            }

            skipCreature.PermanentAttack += PermanentAttackBonus;
        }

        public override string ToString()
        {
            return string.Format("AddAttackWhenSkip({0})", this.PermanentAttackBonus);
        }
    }
}