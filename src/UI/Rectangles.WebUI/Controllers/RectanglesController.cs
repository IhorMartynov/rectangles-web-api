using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rectangles.Application.Contracts.Models;
using Rectangles.Application.Contracts.Requests;

namespace Rectangles.WebUI.Controllers;

/// <summary>
/// Rectangles management.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class RectanglesController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="mediator"></param>
    public RectanglesController(IMediator mediator) =>
        _mediator = mediator;

    /// <summary>
    /// Get rectangles containing the point. Or all rectangles if x or y is blank.
    /// </summary>
    /// <param name="x">X coordinate of the point.</param>
    /// <param name="y">Y coordinate of the point.</param>
    /// <returns></returns>
    [HttpGet]
    public Task<IEnumerable<RectangleDto>> GetRectanglesContainingPoint(
        [FromQuery] double? x,
        [FromQuery] double? y) =>
        x is null || y is null
        ? _mediator.Send(new GetAllRectanglesRequest())
        : _mediator.Send(new GetRectanglesContainingPointRequest(x.Value, y.Value));

    /// <summary>
    /// Search for rectangles containing points.
    /// </summary>
    /// <param name="points">Points collection.</param>
    /// <returns></returns>
    [HttpPost]
    [Route("search")]
    public Task<IEnumerable<RectangleDto>> SearchForRectangles([FromBody] PointDto[] points) =>
        _mediator.Send(new SearchForRectanglesContainingPointsRequest(points));
}