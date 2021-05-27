﻿using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.Contests;
using FullFraim.Models.Contest.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System;
using FullFraim.Models.Dto_s.Phases;

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
                Phases = model.Phases
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
    }
}
