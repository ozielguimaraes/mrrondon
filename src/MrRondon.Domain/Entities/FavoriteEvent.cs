﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MrRondon.Domain.Entities
{
    public class FavoriteEvent
    {
        [Key]
        public Guid FavoriteEventId { get; set; }

        public Guid EventId { get; set; }
        public Event Event { get; set; }

        public Guid PersonId { get; set; }
        public Person Person { get; set; }
    }
}