namespace DesignPatterns.Mediator.After
{
    public abstract class Aircraft
    {
        private readonly IAirTrafficControl _atc;
        private int _currentAltitude;

        protected Aircraft(string callSign, IAirTrafficControl atc)
        {
            CallSign = callSign;
            _atc = atc;
            _atc.RegisterAircraftUnderGuidance(this);
        }

        public abstract int Ceiling { get; }

        public string CallSign { get; private set; }

        public int Altitude
        {
            get => _currentAltitude;
            set
            {
                _currentAltitude = value;
                _atc.ReceiveAircraftLocation(this);
            }
        }

        public void Climb(int heightToClimb) => Altitude += heightToClimb;

        public void WarnOfAirspaceIntrusionBy(Aircraft aircraft)
        {
            // do some work
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) 
                return false;

            var incoming = (Aircraft) obj;
            return this.CallSign.Equals(incoming.CallSign);
        }

        public override int GetHashCode() => CallSign.GetHashCode();
    }
}
