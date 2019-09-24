using System.ComponentModel.DataAnnotations;

namespace EduVault.LearnerProfile
{
    public class ProvidedSupport : Comment
    {
        /// <summary>
        /// E.g. Therapist/Psychologist/Social worker. 
        /// </summary>
        [MaxLength(100)]
        public string SupportFacilitators { get; set; }

        [MaxLength(100)]
        public string BehaviourLearningDifficulties { get; set; }

        [MaxLength(200)]
        public string InterventionStrategies { get; set; }

        [MaxLength(200)]
        public string OutcomesOfIntervention { get; set; }


    }
}