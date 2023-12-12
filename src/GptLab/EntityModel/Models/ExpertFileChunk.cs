﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Models;

[Index(nameof(FullName), IsUnique = false)]
[Index(nameof(FullName), nameof(ConvertIndex), IsUnique = false)]
public class ExpertFileChunk
{
    public ExpertFileChunk()
    {
    }

    public int Id { get; set; }
    public int ExpertFileId { get; set; }
    public ExpertFile ExpertFile { get; set; }
    public int ConvertIndex { get; set; }
    /// <summary>
    /// 存在的目錄之絕對路徑名稱
    /// </summary>
    public string DirectoryName { get; set; } = string.Empty;
    /// <summary>
    /// 檔案名稱 - 含完整路徑名稱
    /// </summary>
    public string FullName { get; set; } = string.Empty;
    /// <summary>
    /// 檔案名稱 - 不含路徑名稱
    /// </summary>
    public string FileName { get; set; } = string.Empty;
    /// <summary>
    /// 檔案大小 - 單位: 位元組 (Byte) ，從檔案系統得到的數據
    /// </summary>
    public string EmbeddingTextFileName { get; set; } = string.Empty;
    public string EmbeddingJsonFileName { get; set; } = string.Empty;
    public long Size { get; set; } = 0L;
    public int TokenSize { get; set; } = 0;
    public Decimal EmbeddingCost { get; set; }
}
