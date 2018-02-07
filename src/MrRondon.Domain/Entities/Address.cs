﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MrRondon.Infra.CrossCutting.Message;

namespace MrRondon.Domain.Entities
{
    public class Address
    {
        [Key]
        public Guid AddressId { get; set; }

        [Display(Name = "Rua/Avenida")]
        [Required(ErrorMessageResourceType = typeof(Error), ErrorMessageResourceName = "Required")]
        [MinLength(5, ErrorMessage = "Mínimo {0} caracteres")]
        [MaxLength(60, ErrorMessage = "Máximo {0} caracteres")]
        public string Street { get; set; }

        [Display(Name = "Bairro")]
        [Required(ErrorMessageResourceType = typeof(Error), ErrorMessageResourceName = "Required")]
        [MinLength(4, ErrorMessage = "Mínimo {0} caracteres")]
        [MaxLength(30, ErrorMessage = "Máximo {0} caracteres")]
        public string Neighborhood { get; set; }

        [Display(Name = "Número")]
        [Required(ErrorMessageResourceType = typeof(Error), ErrorMessageResourceName = "Required")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [MaxLength(6, ErrorMessage = "Máximo {0} caracteres")]
        public string Number { get; set; }

        [DisplayName("Complemento")]
        public string AdditionalInformation { get; set; }
        
        [Display(Name = "CEP")]
        [Required(ErrorMessageResourceType = typeof(Error), ErrorMessageResourceName = "Required")]
        [MaxLength(11, ErrorMessage = "Máximo {0} caracteres")]
        public string ZipCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        [DisplayName("Cidade")]
        public int CityId { get; set; }
        public City City { get; set; }
    }
}