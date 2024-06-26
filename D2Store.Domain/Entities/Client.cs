﻿using AutoMapper;
using D2Store.Domain.Entities.Identity;
using D2Store.Domain.Entities.Items;
using D2Store.Domain.Entities.Lots;
using System.ComponentModel.DataAnnotations.Schema;

namespace D2Store.Domain.Entities
{
    public class Client : BaseEntity
    {
        public int UserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public ClientProfile ClientProfile { get; set; }

        public List<ClientItem> ClientItems { get; set; }

        public List<RequestedItem> RequestedItems { get; set; }

        public List<Client> Friends { get; set; } 

        public List<Lot> Lots { get; set; }

        public List<CartLot> CartLots { get; set; }

        public double Balance { get; set; }
    }
}
