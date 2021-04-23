using Domain.ValueObjects.Base;

namespace Domain.ValueObjects
{
    public class Empate : ValueObjectBase
    {
        public Empate()
        {
            Value = false;
        }

        public bool Value { get; private set; }

        public void Empatar()
        {
            Value = true;
        }

        public void Desempatar()
        {
            Value = false;
        }

        public override string ToString()
        {
            return Value ? "Sim" : "Não";
        }
    }
}