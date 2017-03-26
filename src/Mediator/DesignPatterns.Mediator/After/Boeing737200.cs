namespace DesignPatterns.Mediator.After
{
    public class Boeing737200 : Aircraft
    {
        public Boeing737200(string callSign, IAirTrafficControl atc) : base(callSign, atc)
        {
        }

        public override int Ceiling => 35000;
    }
}
