using ApiCrudDocker.Controllers;
using ApiCrudDocker.Models;
using ApiCrudDocker.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ApiCrudDocker.Tests.Controllers;

public class TransactionsControllerTests
{
    private readonly Mock<ITransactionRepository> _mockRepo;
    private readonly TransactionsController _controller;

    public TransactionsControllerTests()
    {
        // Inicializa o Mock do Repositório
        _mockRepo = new Mock<ITransactionRepository>();
        
        // Injeta o Repositório falso (Mock) no Controller
        _controller = new TransactionsController(_mockRepo.Object);
    }

    [Fact]
    public async Task Get_ReturnsOkResult_WithListOfTransactions()
    {
        // Arrange (Preparação)
        var mockTransactions = new List<Transaction>
        {
            new Transaction { Id = 1, Title = "Salário", Amount = 5000, Type = "Income" },
            new Transaction { Id = 2, Title = "Aluguel", Amount = 1500, Type = "Expense" }
        };
        _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(mockTransactions);

        // Act (Ação)
        var result = await _controller.Get();

        // Assert (Verificação)
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnTransactions = Assert.IsAssignableFrom<IEnumerable<Transaction>>(okResult.Value);
        Assert.Equal(2, returnTransactions.Count());
    }

    [Fact]
    public async Task GetById_ReturnsNotFound_WhenTransactionDoesNotExist()
    {
        // Arrange
        _mockRepo.Setup(repo => repo.GetByIdAsync(99)).ReturnsAsync((Transaction?)null);

        // Act
        var result = await _controller.Get(99);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task GetById_ReturnsOkResult_WhenTransactionExists()
    {
        // Arrange
        var mockTransaction = new Transaction { Id = 1, Title = "Internet", Amount = 100, Type = "Expense" };
        _mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(mockTransaction);

        // Act
        var result = await _controller.Get(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnTransaction = Assert.IsType<Transaction>(okResult.Value);
        Assert.Equal("Internet", returnTransaction.Title);
    }
}