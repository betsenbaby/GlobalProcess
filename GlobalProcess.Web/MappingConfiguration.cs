using Mapster;
using GlobalProcess.Core.Models;
using GlobalProcess.Application.ViewModels;

public static class MappingConfiguration
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<StepViewModel, Step>.NewConfig()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.StepTypeId, src => src.StepTypeId)
            .Map(dest => dest.WorkflowId, src => src.WorkflowId)
            .Map(dest => dest.FormId, src => src.FormId);

        TypeAdapterConfig<Step, StepViewModel>.NewConfig()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.StepTypeId, src => src.StepTypeId)
            .Map(dest => dest.WorkflowId, src => src.WorkflowId)
            .Map(dest => dest.FormId, src => src.FormId);
    }

}
