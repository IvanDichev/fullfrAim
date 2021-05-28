using FullFraim.Data.Models;
using FullFraim.Models.Contest.ViewModels;
using FullFraim.Models.Dto_s.Contests;
using FullFraim.Models.Dto_s.Phases;
using FullFraim.Models.Dto_s.User;
using FullFraim.Models.ViewModels.Dashboard;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Utilities.Mapper
{
    public static class ContestMapper
    {
        public static InputContestDto MapToDto(this CreateContestViewModel model)
        {
            return new InputContestDto()
            {
                Name = model.Name,
                Cover_Url = model.Cover_Url,
                Description = model.Description,
                ContestCategoryId = model.ContestCategoryId,
                ContestTypeId = model.ContestTypeId,
                Phases = model.Phases,
                Jury = model.Jury,
                Participants = model.Participants,
            };
        }

        public static OutputContestDto MapToDto(this Contest model)
        {
            return new OutputContestDto()
            {
                Name = model.Name,
                Cover_Url = model.Cover_Url,
                Description = model.Description,
                ContestCategoryId = model.ContestCategoryId,
                ContestTypeId = model.ContestTypeId,
            };
        }

        public static CreateContestViewModel MapToView(this InputContestDto model)
        {
            return new CreateContestViewModel()
            {
                Name = model.Name,
                Cover_Url = model.Cover_Url,
                Description = model.Description,
                ContestCategoryId = model.ContestCategoryId,
                ContestTypeId = model.ContestTypeId,
            };
        }

        public static Contest MapToRaw(this InputContestDto model)
        {
            return new Contest()
            {
                //Id = model.Id,
                Name = model.Name,
                Cover_Url = model.Cover_Url,
                Description = model.Description,
                ContestCategoryId = model.ContestCategoryId,
                ContestTypeId = model.ContestTypeId,
            };
        }

        public static DashboardViewModel MapToViewDashboard(this OutputContestDto model)  // this ContestDto model
        {
            return new DashboardViewModel()
            {
                Name = model.Name,
                Cover_Url = model.Cover_Url,
                Description = model.Description,
            };
        }

        //public static Contest MapToRaw(this ContestDto model)
        //{
        //    return new Contest()
        //    {
        //        //Id = model.Id,
        //        Name = model.Name,
        //        Cover_Url = model.Cover_Url,
        //        Description = model.Description,
        //        ContestCategoryId = model.ContestCategoryId,
        //        ContestTypeId = model.ContestTypeId,
        //    };
        //}

        public static IQueryable<OutputContestDto> MapToDto(this IQueryable<Contest> query)
        {
            return query.Select(x =>
            new OutputContestDto()
            {
                Id = x.Id,
                Name = x.Name,
                Cover_Url = x.Cover_Url,
                Description = x.Description,
                ContestCategoryId = x.ContestCategoryId,
                ContestTypeId = x.ContestTypeId,
                PhasesInfo = x.ContestPhases.Select(y => new PhaseDto()
                {
                    Name = y.Phase.Name,
                    StartDate = y.StartDate,
                    EndDate = y.EndDate
                }).ToList()
            });
        }

        public static IQueryable<string> MapToUrl(this IQueryable<Contest> query)
        {
            return query
                .Select(x => x.Cover_Url);
        }

        public static IQueryable<UserDto> MapToDto(this IQueryable<User> query)
        {
            return query.Select(q => new UserDto()
            {
                UserId = q.Id,
                FirstName = q.FirstName,
                LastName = q.LastName,
                RankId = q.RankId,
                Points = q.Points
            });
        }

        public static ICollection<JuryContest> MapToJuryContest
            (this ICollection<int> users, int contestId)
        {
            var list = new List<JuryContest>();

            foreach (var user in users)
            {
                var juryContest = new JuryContest()
                {
                    ContestId = contestId,
                    UserId = user,
                };

                list.Add(juryContest);
            }

            return list.ToList();
        }

        public static ICollection<ParticipantContest> MapToParticipantContest
            (this ICollection<int> users, int contestId)
        {
            var list = new List<ParticipantContest>();

            foreach (var user in users)
            {
                var participantContest = new ParticipantContest()
                {
                    ContestId = contestId,
                    UserId = user,
                };

                list.Add(participantContest);
            }

            return list;
        }

        public static ICollection<UserDto> MapToDto
            (this ICollection<User> users)
        {
            var list = new ConcurrentBag<UserDto>();

            Parallel.ForEach(users, user =>
            {
                var userDto = new UserDto()
                {
                    UserId = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    RankId = user.RankId,
                    Points = user.Points
                };

                list.Add(userDto);
            });

            return list.ToList();
        }
    }
}
