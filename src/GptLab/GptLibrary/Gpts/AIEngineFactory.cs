using ShareModel.DataModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GptLibrary.Gpts;

public class AIEngineFactory
{
    private readonly ILogger<AIEngineFactory> logger;
    private readonly IServiceProvider serviceProvider;

    public AIEngineFactory(ILogger<AIEngineFactory> logger,
        IServiceProvider serviceProvider)
    {
        this.logger = logger;
        this.serviceProvider = serviceProvider;
    }

    public IGPTPromptCompletion CreateGptModel(AIEngineEnum aIEngineEnum)
    {
        IGPTPromptCompletion result = null;

        if (aIEngineEnum == AIEngineEnum.AzureOpenAI)
        {
            result = serviceProvider.GetService<GPT35PromptCompletion>();
        }

        return result;
    }

    public IAdaEmbeddingVector CreateEmbeddingModel(AIEngineEnum aIEngineEnum)
    {
        IAdaEmbeddingVector result = null;

        if (aIEngineEnum == AIEngineEnum.AzureOpenAI)
        {
            result = serviceProvider.GetService<AdaEmbeddingVector>();
        }

        return result;
    }
}
