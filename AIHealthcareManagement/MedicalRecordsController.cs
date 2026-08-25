using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AIHealthcareManagement.Models;

namespace AIHealthcareManagement
{
    public class MedicalRecordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedicalRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MedicalRecords
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MedicalRecords.Include(m => m.Appointment).Include(m => m.Doctor).Include(m => m.Patient);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MedicalRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalRecord = await _context.MedicalRecords
                .Include(m => m.Appointment)
                .Include(m => m.Doctor)
                .Include(m => m.Patient)
                .FirstOrDefaultAsync(m => m.RecordId == id);
            if (medicalRecord == null)
            {
                return NotFound();
            }

            return View(medicalRecord);
        }

        // GET: MedicalRecords/Create
        public IActionResult Create()
        {
            ViewData["AppointmentId"] = new SelectList(_context.Appointments, "AppointmentId", "AppointmentId");
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorId");
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId");
            return View();
        }

        // POST: MedicalRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecordId,PatientId,DoctorId,AppointmentId,Diagnosis,ConsultationNotes,RecordDate")] MedicalRecord medicalRecord)
        {
            ModelState.Remove("Doctor");
            ModelState.Remove("Patient");

            medicalRecord.RecordDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Add(medicalRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["AppointmentId"] = new SelectList(
                _context.Appointments,
                "AppointmentId",
                "AppointmentId",
                medicalRecord.AppointmentId
            );

            ViewData["DoctorId"] = new SelectList(
                _context.Doctors,
                "DoctorId",
                "DoctorId",
                medicalRecord.DoctorId
            );

            ViewData["PatientId"] = new SelectList(
                _context.Patients,
                "PatientId",
                "PatientId",
                medicalRecord.PatientId
            );

            return View(medicalRecord);
        }

        // GET: MedicalRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalRecord = await _context.MedicalRecords.FindAsync(id);
            if (medicalRecord == null)
            {
                return NotFound();
            }
            ViewData["AppointmentId"] = new SelectList(_context.Appointments, "AppointmentId", "AppointmentId", medicalRecord.AppointmentId);
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "DoctorId", medicalRecord.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId", medicalRecord.PatientId);
            return View(medicalRecord);
        }

        // POST: MedicalRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
    int id,
    [Bind("RecordId,PatientId,DoctorId,AppointmentId,Diagnosis,ConsultationNotes,RecordDate")]
    MedicalRecord medicalRecord)
        {
            if (id != medicalRecord.RecordId)
            {
                return NotFound();
            }

            // Navigation properties ki validation hatao
            ModelState.Remove("Doctor");
            ModelState.Remove("Patient");
            ModelState.Remove("Appointment");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalRecordExists(medicalRecord.RecordId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["AppointmentId"] = new SelectList(
                _context.Appointments,
                "AppointmentId",
                "AppointmentId",
                medicalRecord.AppointmentId
            );

            ViewData["DoctorId"] = new SelectList(
                _context.Doctors,
                "DoctorId",
                "DoctorId",
                medicalRecord.DoctorId
            );

            ViewData["PatientId"] = new SelectList(
                _context.Patients,
                "PatientId",
                "PatientId",
                medicalRecord.PatientId
            );

            return View(medicalRecord);
        }

        // GET: MedicalRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalRecord = await _context.MedicalRecords
                .Include(m => m.Appointment)
                .Include(m => m.Doctor)
                .Include(m => m.Patient)
                .FirstOrDefaultAsync(m => m.RecordId == id);
            if (medicalRecord == null)
            {
                return NotFound();
            }

            return View(medicalRecord);
        }

        // POST: MedicalRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicalRecord = await _context.MedicalRecords.FindAsync(id);
            if (medicalRecord != null)
            {
                _context.MedicalRecords.Remove(medicalRecord);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalRecordExists(int id)
        {
            return _context.MedicalRecords.Any(e => e.RecordId == id);
        }
    }
}
