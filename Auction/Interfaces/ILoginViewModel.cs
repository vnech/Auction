﻿using Auction.Infrastructure.Interfaces;
using Auction.Models.DTO;

namespace Auction.Interfaces
{
    public interface ILoginViewModel : IViewModel
    {
        UserDTO UserDto { get; set; }

        void Login();
    }
}