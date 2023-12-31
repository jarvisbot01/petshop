using Api.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [Authorize(Roles = "Employee")]
    public class AppointmentController : BaseApiController
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;

        public AppointmentController(IUnitOfWork unitofwork, IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> Get()
        {
            var Appointment = await _unitofwork.Appointments.GetAllAsync();
            return _mapper.Map<List<AppointmentDto>>(Appointment);
        }

        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<AppointmentDto>>> GetPaged(
            [FromQuery] Params appointmentParams
        )
        {
            var appointments = await _unitofwork.Appointments.GetAllAsync(
                appointmentParams.PageIndex,
                appointmentParams.PageSize,
                appointmentParams.Search
            );
            var listAppointmentDto = _mapper.Map<List<AppointmentDto>>(appointments.records);
            return new Pager<AppointmentDto>(
                listAppointmentDto,
                appointments.totalRecords,
                appointmentParams.PageIndex,
                appointmentParams.PageSize,
                appointmentParams.Search
            );
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AppointmentDto>> Get(int id)
        {
            var Appointment = await _unitofwork.Appointments.GetByIdAsync(id);
            if (Appointment == null)
            {
                return NotFound();
            }
            return _mapper.Map<AppointmentDto>(Appointment);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Appointment>> Post(AppointmentDto AppointmentDto)
        {
            var Appointment = _mapper.Map<Appointment>(AppointmentDto);
            _unitofwork.Appointments.Add(Appointment);
            await _unitofwork.SaveAsync();
            if (Appointment == null)
            {
                return BadRequest();
            }
            AppointmentDto.Id = Appointment.Id;
            return CreatedAtAction(nameof(Post), new { id = AppointmentDto.Id }, AppointmentDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AppointmentDto>> Put(
            int id,
            [FromBody] AppointmentDto AppointmentDto
        )
        {
            if (AppointmentDto == null)
            {
                return NotFound();
            }
            var Appointment = _mapper.Map<Appointment>(AppointmentDto);
            _unitofwork.Appointments.Update(Appointment);
            await _unitofwork.SaveAsync();
            return AppointmentDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var Appointment = await _unitofwork.Appointments.GetByIdAsync(id);
            if (Appointment == null)
            {
                return NotFound();
            }
            _unitofwork.Appointments.Remove(Appointment);
            await _unitofwork.SaveAsync();
            return NoContent();
        }
    }
}
