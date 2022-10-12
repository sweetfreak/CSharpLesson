namespace CatWorx.BadgeMaker{

    // reminder, variable declarations look like: dataType variableName = value 

    class Employee
        {
            //write string? with a ? to say "null is ok" - make the variable "nullable"
        private string FirstName;
        private string LastName;
        private int Id;
        private string PhotoUrl;

        public Employee(string firstName, string lastName, int id, string photoUrl) {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            PhotoUrl = photoUrl;
        }

        public string GetFullName() {
            return FirstName + " " + LastName;
        }

        public int GetId() {
            return Id;
        }

        public string GetPhotoUrl() {
            return PhotoUrl;
        }

        public string GetCompanyName() {
            return "Cat Worx";
        }

        }

}