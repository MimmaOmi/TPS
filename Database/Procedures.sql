create or replace 
procedure UpdateStudentDetails
(
pstdname in varchar2,
pStdid in varchar2,
pContactno in varchar2,
pAddress in varchar2,
pEmail in varchar2,
pAccno in number,
pFathername in varchar2,
pMothername in varchar2,
pNid in varchar2

)
as
begin
update t_student set studentname=pstdname,accountno=paccno
,address=paddress,fathername=pfathername
,email=pemail,mothername=pmothername 
,contactno=pcontactno,nid=pnid
where studentid=pStdid;
end UpdateStudentDetails;

================================================================

create or replace 
procedure InsertProvideddocRecord
(
pbankrecno in number,
pStdid in varchar2
)
as
begin
INSERT INTO T_PROVIDEDDOCUMENT (PID, ISSUEDATE, BANKRECEIPTNO, DOCUMENTTYPEID, STUDENTID)
VALUES ((select max(pid)+1 from t_provideddocument), TO_DATE(sysdate, 'DD-MON-RR'), pbankrecno, '1', pStdid);
end InsertProvideddocRecord;