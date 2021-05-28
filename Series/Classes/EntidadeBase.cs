//Classe abstrata com o Id para todas as classes que herdarem dela

namespace DIO.Series
{
    public abstract class EntidadeBase
    {
        public int Id {get; protected set; }
    }
}