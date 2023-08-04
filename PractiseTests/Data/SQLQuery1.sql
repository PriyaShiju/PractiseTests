select * from Certifications

select  certificationTestid,TestPaperName,Active  from TestPaper where active=0 and certificationTestid=2 
group by certificationTestid,TestPaperName,Active
  
exec sp_help TestPaper

update Certifications set Active=1 

