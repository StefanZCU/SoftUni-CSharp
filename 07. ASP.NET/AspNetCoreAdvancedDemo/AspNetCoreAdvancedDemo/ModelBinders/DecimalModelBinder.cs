using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspNetCoreAdvancedDemo.ModelBinders;

public class DecimalModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        ValueProviderResult valueResult = bindingContext.ValueProvider
            .GetValue(bindingContext.ModelName);
        
        
        
        
        
        return Task.CompletedTask;
        
    }
}