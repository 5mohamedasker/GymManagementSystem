using GymManagementSystem.Entities.Enums;

namespace GymManagementSystem.Entities
{
    public class Trainer : GymUser
    {
        public Speciality Speciality { get; set; }

        public ICollection<Session> Sessions { get; set; }
    }
}