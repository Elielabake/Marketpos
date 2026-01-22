Imports Microsoft.Extensions.Caching.Memory
Public Class Class1
    Private Shared cache As New MemoryCache(New MemoryCacheOptions())

    Public Shared Function GetDataFromCache(key As String) As Object
        Dim cachedData As Object = Nothing
        cache.TryGetValue(key, cachedData)
        Return cachedData
    End Function

    Public Shared Sub AddDataToCache(key As String, data As Object, expirationRelativeToNow As TimeSpan)
        Dim cacheEntryOptions As New MemoryCacheEntryOptions()
        cache.Set(key, data, cacheEntryOptions)
    End Sub
End Class
