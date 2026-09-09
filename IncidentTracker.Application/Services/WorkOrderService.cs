using IncidentTracker.Application.DTOs.WorkOrders;
using IncidentTracker.Application.EventHandlers;
using IncidentTracker.Application.Interfaces;
using IncidentTracker.Application.Mapper;
using IncidentTracker.Domain.Entitties;
using IncidentTracker.Domain.Exceptions;

namespace IncidentTracker.Application.Services;
public class WorkOrderService(IWorkOrderRepository workOrderRepository, DomainEventDispatcher eventDispatcher) {

    public async Task Add(AddWorkOrderCommand command) {
        var workOrder = new WorkOrder(command.IncidentId)
            .SetDescription(command.Description)
            .AssignTeam(command.AssignedTeamId)
            .AssignUser(command.AssignedUserId);

        await workOrderRepository.Add(workOrder);
        await workOrderRepository.Save();


        //var domainEvents = workOrder.GetEvents();
        //await eventDispatcher.DispatchAsync(domainEvents);
        //workOrder.ClearDomainEvents();
    }

    public async Task<WorkOrderDto> Get(Guid id) {
        var workOrder = await workOrderRepository.GetById(id);
        var result = workOrder.ToDTO();
        return result;
    }

    public async Task<IEnumerable<WorkOrderDto>> GetByTeamId(Guid teamId) {
        var data = await workOrderRepository.GetByTeamId(teamId);
        var result = data.Select(x => x.ToDTO());
        return result;
    }

    public async Task<IEnumerable<WorkOrderDto>> GetByUserId(Guid userId) {
        var data = await workOrderRepository.GetByUserId(userId);
        var result = data.Select(x => x.ToDTO());
        return result;
    }

    public async Task AssignWorkOrderToTeam(Guid workOrderId, AssignWorkOrderToTeamCommand command) {
        var workOrder = await workOrderRepository.GetById(workOrderId);
        workOrder.AssignTeam(command.TeamId);
        await workOrderRepository.Save();
    }

    public async Task AssignWorkOrderToUser(Guid workOrderId, AssignWorkOrderToUserCommand command) {
        var workOrder = await workOrderRepository.GetById(workOrderId);
        workOrder.AssignUser(command.UserId);
        await workOrderRepository.Save();
    }

    public async Task StartWorkOrder(Guid workOrderId, Guid actorId) {
        var workOrder = await workOrderRepository.GetById(workOrderId);

        if (workOrder.AssignedTeamId != actorId && workOrder.AssignedUserId != actorId) {
            throw new AppException("This WorkOrder Is Not Yours");
        }

        workOrder.StartWorkOrder();
    }

    public async Task CompleteWorkOrder(Guid workOrderId, Guid actorId) {
        var workOrder = await workOrderRepository.GetById(workOrderId);

        if (workOrder.AssignedTeamId != actorId && workOrder.AssignedUserId != actorId) {
            throw new AppException("This WorkOrder Is Not Yours");
        }

        workOrder.CompleteWorkOrder();
    }

    public async Task CancellWorkOrder(Guid workOrderId, Guid actorId) {
        var workOrder = await workOrderRepository.GetById(workOrderId);

        if (workOrder.AssignedTeamId != actorId && workOrder.AssignedUserId != actorId) {
            throw new AppException("This WorkOrder Is Not Yours");
        }

        workOrder.CancellWorkOrder();

    }

    public async Task<IEnumerable< WorkOrderDto>> GetAllWorkOrder()
    {
        var result = await workOrderRepository.GetAll();
        var dtos = result.Select((x => x.ToDTO()));
        return dtos;
    }
        

}
