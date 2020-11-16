using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.CustomEntities.User
{
    public class AddUser
    {
        [Required(ErrorMessage = "Nome é obrigatório.")]
        [MaxLength(50)]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Sobrenome é obrigatório.")]
        [MaxLength(50)]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        [MaxLength(320)]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Data de nascimento é obrigatória.")]
        public DateTime DateOfBirth { get; set; }
        
        [Required(ErrorMessage = "Escolaridade é obrigatória.")]
        public int Schooling { get; set; }


    }
}
