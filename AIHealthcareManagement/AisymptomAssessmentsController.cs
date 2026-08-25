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
    public class AisymptomAssessmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AisymptomAssessmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AisymptomAssessments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AisymptomAssessments.Include(a => a.Patient);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AisymptomAssessments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aisymptomAssessment = await _context.AisymptomAssessments
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(m => m.AssessmentId == id);
            if (aisymptomAssessment == null)
            {
                return NotFound();
            }

            return View(aisymptomAssessment);
        }

        // GET: AisymptomAssessments/Create
        public IActionResult Create()
        {
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId");
            return View();
        }

        // POST: AisymptomAssessments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // POST: AisymptomAssessments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("PatientId,SymptomsInput")]
    AisymptomAssessment aisymptomAssessment)
        {
            // Remove validation for values generated automatically
            ModelState.Remove("Patient");
            ModelState.Remove("AiresultSummary");
            ModelState.Remove("UrgencyLevel");
            ModelState.Remove("ConfidenceScore");
            ModelState.Remove("ModelVersion");
            ModelState.Remove("CreatedAt");

            if (ModelState.IsValid)
            {
                string symptoms = aisymptomAssessment.SymptomsInput.ToLower();

                // Default assessment
                aisymptomAssessment.UrgencyLevel = "Low";
                aisymptomAssessment.ConfidenceScore = 0.70m;
                aisymptomAssessment.AiresultSummary =
                    "The reported symptoms appear to require routine medical attention.";

                // High urgency
                if (symptoms.Contains("chest pain") ||
                    symptoms.Contains("difficulty breathing") ||
                    symptoms.Contains("unconscious") ||
                    symptoms.Contains("severe bleeding"))
                {
                    aisymptomAssessment.UrgencyLevel = "High";
                    aisymptomAssessment.ConfidenceScore = 0.95m;
                    aisymptomAssessment.AiresultSummary =
                        "Potentially serious symptoms detected. Immediate medical attention is recommended.";
                }

                // Medium urgency
                else if (symptoms.Contains("fever") ||
                         symptoms.Contains("vomiting") ||
                         symptoms.Contains("severe pain") ||
                         symptoms.Contains("dizziness"))
                {
                    aisymptomAssessment.UrgencyLevel = "Medium";
                    aisymptomAssessment.ConfidenceScore = 0.85m;
                    aisymptomAssessment.AiresultSummary =
                        "The reported symptoms may require medical consultation. Please monitor the condition and consult a healthcare professional.";
                }

                // Low urgency
                else if (symptoms.Contains("headache") ||
                         symptoms.Contains("cold") ||
                         symptoms.Contains("cough") ||
                         symptoms.Contains("tired"))
                {
                    aisymptomAssessment.UrgencyLevel = "Low";
                    aisymptomAssessment.ConfidenceScore = 0.75m;
                    aisymptomAssessment.AiresultSummary =
                        "The reported symptoms appear mild. Rest, hydration, and routine medical consultation may be considered if symptoms continue.";
                }

                aisymptomAssessment.ModelVersion = "Rule-Based AI v1.0";
                aisymptomAssessment.CreatedAt = DateTime.Now;

                _context.AisymptomAssessments.Add(aisymptomAssessment);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["PatientId"] = new SelectList(
                _context.Patients,
                "PatientId",
                "FullName",
                aisymptomAssessment.PatientId
            );

            return View(aisymptomAssessment);
        }

        // GET: AisymptomAssessments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aisymptomAssessment = await _context.AisymptomAssessments.FindAsync(id);
            if (aisymptomAssessment == null)
            {
                return NotFound();
            }
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId", aisymptomAssessment.PatientId);
            return View(aisymptomAssessment);
        }

        // POST: AisymptomAssessments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // POST: AisymptomAssessments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("AssessmentId,PatientId,SymptomsInput,AiresultSummary,UrgencyLevel,ConfidenceScore,ModelVersion,CreatedAt")]
    AisymptomAssessment aisymptomAssessment)
        {
            if (id != aisymptomAssessment.AssessmentId)
            {
                return NotFound();
            }

            // Navigation property validation remove karo
            ModelState.Remove("Patient");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aisymptomAssessment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AisymptomAssessmentExists(aisymptomAssessment.AssessmentId))
                    {
                        return NotFound();
                    }

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["PatientId"] = new SelectList(
                _context.Patients,
                "PatientId",
                "FullName",
                aisymptomAssessment.PatientId
            );

            return View(aisymptomAssessment);
        }

        // GET: AisymptomAssessments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aisymptomAssessment = await _context.AisymptomAssessments
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(m => m.AssessmentId == id);
            if (aisymptomAssessment == null)
            {
                return NotFound();
            }

            return View(aisymptomAssessment);
        }

        // POST: AisymptomAssessments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aisymptomAssessment = await _context.AisymptomAssessments.FindAsync(id);
            if (aisymptomAssessment != null)
            {
                _context.AisymptomAssessments.Remove(aisymptomAssessment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AisymptomAssessmentExists(int id)
        {
            return _context.AisymptomAssessments.Any(e => e.AssessmentId == id);
        }
    }
}
