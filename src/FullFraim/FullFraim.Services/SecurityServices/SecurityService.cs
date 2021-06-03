﻿using FullFraim.Data;
using FullFraim.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared;
using System.Threading.Tasks;

namespace FullFraim.Services.SecurityServices
{
    public class SecurityService : ISecurityService
    {
        private readonly FullFraimDbContext context;
        private readonly UserManager<User> userManager;

        public SecurityService(FullFraimDbContext context)
        {
            this.context = context;
        }
        
        public SecurityService(FullFraimDbContext context,
            UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

      
        public async Task<bool> IsUserJuryInContestAsync(int userId, int contestId)
        {
            return await this.context.JuryContests
                .AnyAsync(jc => jc.UserId == userId && jc.ContestId == contestId);
        }

        public async Task<bool> IsUserParticipantInContestAsync(int userId, int contestId)
        {
            return await this.context.ParticipantContests
                .AnyAsync(pc => pc.UserId == userId && pc.ContestId == contestId);
        }

        public async Task<bool> IsUserAdmin(int userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());

            return await userManager.IsInRoleAsync(user, Constants.Roles.Admin);
        }
    }
}
