﻿using System.Linq;
using Auction.Data;
using Auction.Models.DTO;
using AuctionService.Interfaces;
using AutoMapper;
using Caliburn.Micro;

namespace AuctionService.Services
{
    public class AccountControler : PropertyChangedBase, IAccountController
    {
        private AuctionContext _context;
        private UserDTO _currentUser;

        public AccountControler()
            : this(new AuctionContext())
        {

        }

        public AccountControler(AuctionContext context)
        {
            _context = context;
        }

        public bool Login(UserDTO user)
        {
            var entity = _context.Users.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);

            if (entity != null)
            {
                CurrentUserInit(entity);
                return true;
            }

            return false;
        }

        public void LogOut()
        {
        }

        public void SignUp(UserDTO userDto)
        {
            var entity = Mapper.Map<Auction.Data.User>(userDto);

            entity = _context.Users.Add(entity);

            _context.SaveChanges();

            CurrentUserInit(entity);
        }

        public bool IsAuthentificated
        {
            get { return CurrentUser != null; }
        }

        public UserDTO CurrentUser
        {
            get { return _currentUser; }
            private set
            {
                if (Equals(value, _currentUser)) return;
                _currentUser = value;
                NotifyOfPropertyChange();
            }
        }

        private void CurrentUserInit(User user)
        {
            CurrentUser = Mapper.Map<UserDTO>(user);
        }
    }
}
