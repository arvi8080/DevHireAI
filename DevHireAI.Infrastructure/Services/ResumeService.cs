using DevHireAI.Application.DTOs.Resume;
using DevHireAI.Application.Interfaces.Repositories;
using DevHireAI.Application.Interfaces.Services;
using DevHireAI.Domain.Entities;

namespace DevHireAI.Infrastructure.Services;

public class ResumeService : IResumeService
{
    private readonly IResumeRepository _resumeRepository;

    public ResumeService(IResumeRepository resumeRepository)
    {
        _resumeRepository = resumeRepository;
    }

    public async Task UploadResumeAsync(UploadResumeRequest request, Guid userId)
    {
        var existingResume = await _resumeRepository.GetByUserIdAsync(userId);

        if (existingResume != null)
        {
            await _resumeRepository.DeleteAsync(existingResume);
        }

        var resume = new Resume
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            FileName = request.FileName,
            FilePath = request.FilePath,
            UploadedAt = DateTime.UtcNow
        };

        await _resumeRepository.AddAsync(resume);
    }

    public async Task<ResumeResponse?> GetMyResumeAsync(Guid userId)
    {
        var resume = await _resumeRepository.GetByUserIdAsync(userId);

        if (resume == null)
            return null;

        return new ResumeResponse
        {
            Id = resume.Id,
            UserId = resume.UserId,
            FileName = resume.FileName,
            FilePath = resume.FilePath,
            UploadedAt = resume.UploadedAt
        };
    }

    public async Task DeleteResumeAsync(Guid userId)
    {
        var resume = await _resumeRepository.GetByUserIdAsync(userId);

        if (resume == null)
            throw new Exception("Resume not found.");

        await _resumeRepository.DeleteAsync(resume);
    }
}