using System;
using System.Linq;
using StudentManagement.Models;
using StudentManagment.Data;

public class YourDbContextTests
{
    public void DodajDaneDoBazy_DaneDodanePrawidlowo()
    {
        // Arrange
        using (var dbContext = new StudentManagmentDbContext())
        {
            // Act
            dbContext.Students.Add
            dbContext.SaveChanges();
        }

        // Assert
        using (var dbContext = new YourDbContext())
        {
            var addedData = dbContext.YourModels.FirstOrDefault(x => x.Name == "Testowe dane");
            Assert.IsNotNull(addedData, "Dane nie zostały dodane do bazy.");
        }
    }

    // Dodaj inne testy jednostkowe dla różnych operacji (aktualizacja, usunięcie, pobieranie danych, itp.)
}
