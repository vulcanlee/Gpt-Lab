using Azure.AI.OpenAI;
using EntityModel.Models;
using GptService.Services;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ShareModel.DataModels;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GptService.Helpers;

public class SearchCollectionBuilderHelper
{
    private readonly EmbeddingSearchHelper embeddingSearchHelper;
    private readonly GptExpertFileService gptExpertFileService;
    private readonly ILogger<SearchCollectionBuilderHelper> logger;

    public SearchCollectionBuilderHelper(EmbeddingSearchHelper embeddingSearchHelper,
        GptExpertFileService gptExpertFileService,
        ILogger<SearchCollectionBuilderHelper> logger)
    {
        this.embeddingSearchHelper = embeddingSearchHelper;
        this.gptExpertFileService = gptExpertFileService;
        this.logger = logger;
    }

    public async Task BuildAsync()
    {
        embeddingSearchHelper.Reset();
        ServiceResult<List<ExpertFile>> expertFileResult =
            await gptExpertFileService.GetAllEmbeddingAsync();
        if(expertFileResult.Status == true)
        {
            List<ExpertFile> expertFiles = expertFileResult.Payload;
            foreach (var expertFile in expertFiles)
            {
                await embeddingSearchHelper.AddAsync(expertFile);
            }
        }    
    }
}
