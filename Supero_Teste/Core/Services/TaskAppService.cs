using System;
using AutoMapper;
using Core.Models;
using Domain;
using Domain.Entity;
using Domain.Enum;

namespace Core.Services
{
    public class TaskAppService
    {
        private readonly IRepository<TaskEntity> taskRepository;
        private readonly IMapper mapper;

        public TaskAppService(IRepository<TaskEntity> taskRepository, IMapper mapper)
        {
            this.taskRepository = taskRepository;
            this.mapper = mapper;
        }

        public void Add(TaskRequest taskRequest)
        {
            var task = mapper.Map<TaskRequest, TaskEntity>(taskRequest);

            taskRepository.Add(task);
            taskRepository.SaveChanges();
        }

        public TaskResponse Update(TaskRequest taskRequest)
        {
            var task = taskRepository.GetById(taskRequest.Id);
            if (task != null)
            {
                if (!string.IsNullOrEmpty(taskRequest.Title))
                {
                    task.Title = taskRequest.Title;
                }

                if (!string.IsNullOrEmpty(taskRequest.Description))
                {
                    task.Description = taskRequest.Description;
                }
                
                task.Status = (int)taskRequest.Status;
                task.EditionDate = DateTime.Now;

                CheckStatus(task, taskRequest.Status);

                task = taskRepository.Update(task);
                taskRepository.SaveChanges();

                return mapper.Map<TaskEntity, TaskResponse>(task);
            }

            return null;
        }

        private static void CheckStatus(TaskEntity task, EStatus status)
        {
            if (status == EStatus.Concluded)
            {
                task.ConclusionDate = DateTime.Now;
            }
            else
            {
                task.ConclusionDate = null;
            }
        }

        public TaskResponse GetById(int id)
        {
            var task = taskRepository.GetById(id);
            if (task != null)
            {
                return mapper.Map<TaskEntity, TaskResponse>(task);
            }

            return null;
        }

        public bool Delete(int id)
        {
            var task = taskRepository.GetById(id);
            if (task != null)
            {
                taskRepository.Delete(id);
                taskRepository.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
