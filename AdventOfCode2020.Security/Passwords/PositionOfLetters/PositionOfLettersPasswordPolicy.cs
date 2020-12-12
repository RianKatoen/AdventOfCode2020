namespace AdventOfCode2020.Security.Passwords.PositionOfLetters
{
    public class PositionOfLettersPasswordPolicy : IPasswordPolicy
    {
        private readonly int _positionA;
        public int PositionA => _positionA + 1;

        private readonly int _positionB;
        public int PositionB => _positionB + 1;

        public readonly char Character;

        public PositionOfLettersPasswordPolicy(int positionA, int positionB, char character)
        {
            _positionA = positionA - 1;
            _positionB = positionB - 1;
            Character = character;
        }

        public bool Verify(string password)
        {
            return password[_positionA] == Character ^ password[_positionB] == Character;
        }
    }
}

