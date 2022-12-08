drop database registration;
CREATE DATABASE registration;
USE registration;
SET FOREIGN_KEY_CHECKS=0;

CREATE TABLE applicant(
APP_CODE INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
LAST_NAME VARCHAR(30),
FIRST_NAME VARCHAR(30),
MID_NAME VARCHAR(30),
BIRTHDAY DATE,
AGE INT,
SEX CHAR,
ADDRESS VARCHAR(100),
GARAGE BOOLEAN,
CONT_NUM VARCHAR(11)
#FOREIGN KEY (BRANCH_CODE) REFERENCES registrar(BRANCH_CODE)
#FOREIGN KEY (REGION_CODE) REFERENCES region(REGION_CODE)
);

CREATE TABLE driver_license(
DL_NUM VARCHAR(20) KEY NOT NULL,
DL_DESC VARCHAR(20),
DL_CODES VARCHAR(10),
EXP_DATE DATE
);

CREATE TABLE form(
FORM_NUM INT KEY NOT NULL AUTO_INCREMENT,
CERT_COVER BOOLEAN,
POLICE_CLEARANCE BOOLEAN,
CERT_STOCK BOOLEAN,
PAYMENT_REF_NUM BOOLEAN,
TIN_NUM VARCHAR(20),
DATE_REG DATE,
QUALIFICATION VARCHAR(10)
#FOREIGN KEY (EMM_CODE) REFERENCES emission(EMM_CODE),
#FOREIGN KEY (DL_NUM) REFERENCES driver_license(DL_NUM)
);

CREATE TABLE vehicle_info(
VIN VARCHAR(20) KEY NOT NULL,
PLATE_NUM VARCHAR(20),
VEH_CLASS INT,
VEH_COLOR VARCHAR(20)
#FOREIGN KEY (APP_CODE) REFERENCES applicant(APP_CODE)
);



CREATE TABLE car_model(
CM_CODE VARCHAR(20) KEY NOT NULL,
MODEL VARCHAR(20), 
MODEL_YEAR YEAR,
MANUFACTURER VARCHAR(20),
CAR_TYPE VARCHAR(20)
);

CREATE TABLE registrar(
BRANCH_CODE INT KEY NOT NULL,
BRANCH_LOC VARCHAR(40)
#FOREIGN KEY (REGION_CODE) REFERENCES registration(REGION_CODE),
);

CREATE TABLE region(
REGION_CODE VARCHAR(20) KEY NOT NULL
);

CREATE TABLE expense(
EM_PRICE INT KEY NOT NULL,
REG_PRICE INT
);

CREATE TABLE emission(
EMM_CODE INT KEY NOT NULL AUTO_INCREMENT,
CERT_EMM_COMPLIANCE BOOLEAN NOT NULL,
OG_SALES_INV BOOLEAN
);

CREATE TABLE account(
USERNAME VARCHAR(20) KEY NOT NULL,
USERPASS VARCHAR(20),
acct_type VARCHAR(10)
);

#ALTER TABLE vehicle_info AUTO_INCREMENT = 0000;
ALTER TABLE vehicle_info
ADD COLUMN(
APP_CODE INT, FOREIGN KEY (APP_CODE) REFERENCES applicant(APP_CODE),
CM_CODE VARCHAR(20), FOREIGN KEY(CM_CODE) REFERENCES car_model(CM_CODE),
EMM_CODE INT, FOREIGN KEY(EMM_CODE) REFERENCES emission(EMM_CODE)
);

ALTER TABLE applicant AUTO_INCREMENT = 100;
ALTER TABLE applicant
ADD COLUMN(
USERNAME VARCHAR(20), FOREIGN KEY(USERNAME) REFERENCES account(USERNAME),
BRANCH_CODE INT, FOREIGN KEY (BRANCH_CODE) REFERENCES registrar(BRANCH_CODE),
REGION_CODE VARCHAR(20), FOREIGN KEY (REGION_CODE) REFERENCES region(REGION_CODE),
DL_NUM VARCHAR(20), FOREIGN KEY (DL_NUM) REFERENCES driver_license(DL_NUM)
);

ALTER TABLE form AUTO_INCREMENT = 200;
ALTER TABLE form
ADD COLUMN(
EMM_CODE INT, FOREIGN KEY (EMM_CODE) REFERENCES emission(EMM_CODE),
BRANCH_CODE INT, FOREIGN KEY (BRANCH_CODE) REFERENCES registrar(BRANCH_CODE),
APP_CODE INT, FOREIGN KEY (APP_CODE) REFERENCES applicant(APP_CODE)
);

ALTER TABLE registrar
ADD COLUMN(
REGION_CODE VARCHAR(20) , FOREIGN KEY (REGION_CODE) REFERENCES region(REGION_CODE)
);

ALTER TABLE emission AUTO_INCREMENT = 300;
/*ALTER TABLE emission
ADD COLUMN(
VIN VARCHAR(20) , FOREIGN KEY (VIN) REFERENCES vehicle_info(VIN)
);*/

INSERT INTO region(REGION_CODE) VALUES("Region 1");
INSERT INTO region(REGION_CODE) VALUES("Region 2");
INSERT INTO region(REGION_CODE) VALUES("Region 3");
INSERT INTO region(REGION_CODE) VALUES("CALABARZON");
INSERT INTO region(REGION_CODE) VALUES("MIMAROPA");
INSERT INTO region(REGION_CODE) VALUES("Region 5");
INSERT INTO region(REGION_CODE) VALUES("Region 6");
INSERT INTO region(REGION_CODE) VALUES("Region 7");
INSERT INTO region(REGION_CODE) VALUES("Region 8");
INSERT INTO region(REGION_CODE) VALUES("Region 9");
INSERT INTO region(REGION_CODE) VALUES("Region 10");
INSERT INTO region(REGION_CODE) VALUES("Region 11");
INSERT INTO region(REGION_CODE) VALUES("Region 12");
INSERT INTO region(REGION_CODE) VALUES("Region 13");
INSERT INTO region(REGION_CODE) VALUES("NCR");
INSERT INTO region(REGION_CODE) VALUES("CAR");

INSERT INTO registrar(BRANCH_CODE, BRANCH_LOC, REGION_CODE) VALUES(010012504, "San Fransisco, La Union", "Region 1");
INSERT INTO registrar(BRANCH_CODE, BRANCH_LOC, REGION_CODE) VALUES(010023500, "Tuguegarao, Cagayan", "Region 2");
INSERT INTO registrar(BRANCH_CODE, BRANCH_LOC, REGION_CODE) VALUES(010032010, "San Fransisco, Pampanga", "Region 3");
INSERT INTO registrar(BRANCH_CODE, BRANCH_LOC, REGION_CODE) VALUES(010044217, "Lipa City, Batangas", "CALABARZON");
INSERT INTO registrar(BRANCH_CODE, BRANCH_LOC, REGION_CODE) VALUES(010045201, "Oriental Mindoro", "MIMAROPA");
INSERT INTO registrar(BRANCH_CODE, BRANCH_LOC, REGION_CODE) VALUES(010054500, "Legaspi City, Albay", "Region 5");
INSERT INTO registrar(BRANCH_CODE, BRANCH_LOC, REGION_CODE) VALUES(010065000, "Iloilo City", "Region 6");
INSERT INTO registrar(BRANCH_CODE, BRANCH_LOC, REGION_CODE) VALUES(010076000, "Cebu City", "Region 7");
INSERT INTO registrar(BRANCH_CODE, BRANCH_LOC, REGION_CODE) VALUES(010086500, "Tacloban City", "Region 8");
INSERT INTO registrar(BRANCH_CODE, BRANCH_LOC, REGION_CODE) VALUES(010097000, "Zamboanga City", "Region 9");
INSERT INTO registrar(BRANCH_CODE, BRANCH_LOC, REGION_CODE) VALUES(010109000, "Cagayan de Oro City", "Region 10");
INSERT INTO registrar(BRANCH_CODE, BRANCH_LOC, REGION_CODE) VALUES(010118000, "Davao City", "Region 11");
INSERT INTO registrar(BRANCH_CODE, BRANCH_LOC, REGION_CODE) VALUES(010129506, "Koronadal City", "Region 12");
INSERT INTO registrar(BRANCH_CODE, BRANCH_LOC, REGION_CODE) VALUES(010138600, "Butuan City", "Region 13");
INSERT INTO registrar(BRANCH_CODE, BRANCH_LOC, REGION_CODE) VALUES(010141008, "Quezon City", "NCR");
INSERT INTO registrar(BRANCH_CODE, BRANCH_LOC, REGION_CODE) VALUES(010152600, "Baguio City", "CAR");

INSERT INTO car_model(CM_CODE, MODEL, MODEL_YEAR, MANUFACTURER, CAR_TYPE)
	VALUES("CM101","Altima", "2020", "Nissan", "Sedan");  

INSERT INTO car_model(CM_CODE, MODEL, MODEL_YEAR, MANUFACTURER, CAR_TYPE)
	VALUES("CM102","Innova", "2019", "Toyota", "SUV");  

INSERT INTO car_model(CM_CODE, MODEL, MODEL_YEAR, MANUFACTURER, CAR_TYPE)
	VALUES("CM103","Accent", "2018", "Hyundai", "Hatchback");

INSERT INTO car_model(CM_CODE, MODEL, MODEL_YEAR, MANUFACTURER, CAR_TYPE)
	VALUES("CM104","Fuso Colt", "2022", "Mitsubishi", "Light Truck");  

INSERT INTO car_model(CM_CODE, MODEL, MODEL_YEAR, MANUFACTURER, CAR_TYPE)
	VALUES("CM105","Corolla Altis", "2022", "Toyota", "Sedan");  

INSERT INTO car_model(CM_CODE, MODEL, MODEL_YEAR, MANUFACTURER, CAR_TYPE)
	VALUES("CM106","Civic", "2018", "Honda", "Sedan");  

INSERT INTO car_model(CM_CODE, MODEL, MODEL_YEAR, MANUFACTURER, CAR_TYPE)
	VALUES("CM107","Fortuner", "2016", "Toyota", "SUV");  

INSERT INTO car_model(CM_CODE, MODEL, MODEL_YEAR, MANUFACTURER, CAR_TYPE)
	VALUES("CM108","Civic", "2018", "Honda", "Sedan");  

INSERT INTO car_model(CM_CODE, MODEL, MODEL_YEAR, MANUFACTURER, CAR_TYPE)
	VALUES("CM109","Everest", "2012", "Ford", "SUV");  
    
INSERT INTO car_model(CM_CODE, MODEL, MODEL_YEAR, MANUFACTURER, CAR_TYPE)
	VALUES("CM110","MUX", "2017", "Isuzu", "SUV");  

#PERSON 1
INSERT INTO driver_license(DL_NUM, DL_DESC, DL_CODES, EXP_DATE)
	VALUES("112","non-prof","B, BA", "2026-05-12");
    
INSERT INTO account(USERNAME,USERPASS, acct_type)
	VALUES("user1","password","user");

INSERT INTO applicant(LAST_NAME, FIRST_NAME, MID_NAME, BIRTHDAY, AGE, SEX ,ADDRESS , GARAGE , CONT_NUM, BRANCH_CODE, REGION_CODE, USERNAME,DL_NUM)
	VALUES("Daliuag", "Ronan", "Gavino", "2002-07-11",  (DATE_FORMAT(FROM_DAYS(DATEDIFF(NOW(),BIRTHDAY)), '%Y') + 0),"M", "etc", 1,  "0905722757", "010012504", 
    (SELECT region.REGION_CODE FROM registrar inner join region where BRANCH_CODE='010023500' and region.REGION_CODE=registrar.REGION_CODE),"user1","112");
  
#CAR INFO 1
INSERT INTO emission( CERT_EMM_COMPLIANCE, OG_SALES_INV)
	VALUES(1,1);
    
INSERT INTO vehicle_info(VIN, VEH_CLASS, VEH_COLOR,  APP_CODE,CM_CODE,EMM_CODE)
	VALUES("MNAUMFF50FW423340", "1", "red",  "100","CM101",300);
    
INSERT INTO form(CERT_COVER, POLICE_CLEARANCE, CERT_STOCK, PAYMENT_REF_NUM, TIN_NUM, DATE_REG, QUALIFICATION, EMM_CODE, BRANCH_CODE,APP_CODE)
	VALUES(1,0,0,1,"1234", CURRENT_DATE(), 0, 300,"010012504",100);
    
#CAR INFO 2
INSERT INTO emission( CERT_EMM_COMPLIANCE, OG_SALES_INV)
	VALUES(1,1);
    
INSERT INTO vehicle_info(VIN, VEH_CLASS, VEH_COLOR, PLATE_NUM, APP_CODE,CM_CODE,EMM_CODE)
	VALUES("MNAUMFF20FW4233220", "1", "white", "BMP 2231", "100","CM110",301);

INSERT INTO form(CERT_COVER, POLICE_CLEARANCE, CERT_STOCK, PAYMENT_REF_NUM, TIN_NUM, DATE_REG, QUALIFICATION, EMM_CODE, BRANCH_CODE,APP_CODE)
	VALUES(1,1,1,1,"5678", CURRENT_DATE(), 0, 301,"010012504",100);

#PERSON 2
INSERT INTO driver_license(DL_NUM, DL_DESC, DL_CODES, EXP_DATE)
	VALUES("C21-04-005432","non-prof","1, 2", "2025-11-23");
    
INSERT INTO account(USERNAME,USERPASS, acct_type)
	VALUES("user2","password2","user");

INSERT INTO applicant(LAST_NAME, FIRST_NAME, MID_NAME, BIRTHDAY, AGE, SEX ,ADDRESS , GARAGE , CONT_NUM, BRANCH_CODE, REGION_CODE, USERNAME, DL_NUM)
	VALUES("Sta Cruz", "Levin Jacob", "Gonzales", "2002-11-23",  (DATE_FORMAT(FROM_DAYS(DATEDIFF(NOW(),BIRTHDAY)), '%Y') + 0),"M", "etc", 1,  "09337326478", "010012504", 
    (SELECT region.REGION_CODE FROM registrar inner join region where BRANCH_CODE='010012504' and region.REGION_CODE=registrar.REGION_CODE),"user2","C21-04-005432");

    
#CAR INFO 3
INSERT INTO emission( CERT_EMM_COMPLIANCE, OG_SALES_INV)
	VALUES(0,0);
    
INSERT INTO vehicle_info(VIN, VEH_CLASS, VEH_COLOR, APP_CODE,CM_CODE,EMM_CODE)
	VALUES("ABCDE20FW4233220", "1", "GREEN",  "101","CM110",302);

INSERT INTO form(CERT_COVER, POLICE_CLEARANCE, CERT_STOCK, PAYMENT_REF_NUM, TIN_NUM, DATE_REG, QUALIFICATION, EMM_CODE, BRANCH_CODE,APP_CODE)
	VALUES(1,1,1,1,"5678", CURRENT_DATE(), 0, 302,"010012504",101);
    
UPDATE form, emission Set Qualification = CASE WHEN CERT_COVER=1 and POLICE_CLEARANCE=1 and CERT_STOCK=1 and PAYMENT_REF_NUM = 1 
                and emission.CERT_EMM_COMPLIANCE = 1 and emission.OG_SALES_INV = 1 
                then '1' else '0' end where emission.EMM_CODE=form.EMM_CODE;    

UPDATE vehicle_info, applicant
set PLATE_NUM = 
	CASE applicant.REGION_CODE
		WHEN 'Region 1' THEN  concat('AAA ','0',vehicle_info.EMM_CODE)
        WHEN 'Region 2' THEN  concat('BAA ','0',vehicle_info.EMM_CODE)
        WHEN 'Region 3' THEN  concat('CAA ','0',vehicle_info.EMM_CODE)
        WHEN 'CALABARZON' THEN  concat('DAA ','0',vehicle_info.EMM_CODE)
        WHEN 'MIMAROPA' THEN  concat('EAA ','0',vehicle_info.EMM_CODE)
        WHEN 'Region 5' THEN  concat('FAA ','0',vehicle_info.EMM_CODE)
        WHEN 'Region 6' THEN  concat('GAA ','0',vehicle_info.EMM_CODE)
        WHEN 'Region 7' THEN  concat('HAA ','0',vehicle_info.EMM_CODE)
        WHEN 'Region 8' THEN  concat('IAA ','0',vehicle_info.EMM_CODE)
        WHEN 'Region 9' THEN  concat('JAA ','0',vehicle_info.EMM_CODE)
        WHEN 'Region 10' THEN  concat('KAA ','0',vehicle_info.EMM_CODE)
        WHEN 'Region 11' THEN  concat('LAA ','0',vehicle_info.EMM_CODE)
        WHEN 'Region 12' THEN  concat('MAA ','0',vehicle_info.EMM_CODE)
        WHEN 'Region 13' THEN  concat('NAA ','0',vehicle_info.EMM_CODE)
        WHEN 'NCR' THEN  concat('OAA ','0',vehicle_info.EMM_CODE)
        WHEN 'CAR' THEN  concat('PAA ','0',vehicle_info.EMM_CODE)
	END
WHERE vehicle_info.APP_CODE=applicant.APP_CODE;   
/*
Select * from applicant inner join vehicle_info WHERE vehicle_info.APP_CODE=applicant.APP_CODE; 

Select FIRST_NAME, MID_NAME, LAST_NAME, SEX, ADDRESS, GARAGE, CONT_NUM As 'Phone #', BRANCH_CODE
	from applicant where APP_CODE=100;



SELECT region.REGION_CODE FROM registrar inner join region where BRANCH_CODE=010012504 and region.REGION_CODE=registrar.REGION_CODE;
#SELECT REGION_CODE FROM registrar inner join region where BRANCH_CODE=;
#END OF SAMPLE INPUTS

#SELECT QUERIES
SELECT * FROM account;
SELECT * FROM applicant;
SELECT * FROM driver_license;
SELECT * FROM vehicle_info;
SELECT * FROM emission;
SELECT * FROM form;
SELECT * FROM emission inner join vehicle_info where vehicle_info.EMM_CODE=emission.EMM_CODE;



#SELECT APPLICANT WITH ALL FORM NUM AND VIN
#SELECT applicant.APP_CODE, concat(LAST_NAME,', ',FIRST_NAME) As Name, FORM_NUM, VIN FROM applicant inner join form inner join vehicle_info 
#	where applicant.APP_CODE=form.APP_CODE and applicant.APP_CODE=vehicle_info.APP_CODE and vehicle_info.EMM_CODE=form.EMM_CODE;

/*
#EMPLOYEE HOME LOAD
#SELECT applicant.APP_CODE as 'App #', concat(LAST_NAME,', ',FIRST_NAME) As Name, registrar.BRANCH_LOC AS Branch, DATE_ADD(DATE_REG, INTERVAL 10 year) AS DATE, 
#	if (QUALIFICATION=1, 'Yes', 'No') as Qualification, form.FORM_NUM FROM registration.applicant inner join registration.form inner join registrar where form.BRANCH_CODE=registrar.BRANCH_CODE and 
#   form.APP_CODE = applicant.APP_CODE;
    
#EMPLOYEE UPDATE QUERY
#SELECT  FORM_NUM, concat(LAST_NAME,', ',FIRST_NAME) As Name, CERT_EMM_COMPLIANCE AS Q1, OG_SALES_INV AS Q2, CERT_COVER AS Q3, POLICE_CLEARANCE AS Q4, CERT_STOCK AS Q5, PAYMENT_REF_NUM AS Q6, VEH_COLOR, PLATE_NUM from applicant inner join emission
#inner join form inner join vehicle_info where applicant.APP_CODE= 100 and applicant.APP_CODE = vehicle_info.APP_CODE and emission.EMM_CODE=vehicle_info.EMM_CODE and form.EMM_CODE=form.EMM_CODE;

#Working login query
#SELECT Count(*) AS YN, APP_CODE, FIRST_NAME from account inner join applicant where applicant.USERNAME=account.USERNAME and account.USERNAME='user2' and account.USERPASS = 'password2';

#NewAdminHome
#Select applicant.APP_CODE AS 'App #',concat(LAST_NAME,', ',FIRST_NAME, ', ' , MID_NAME) As Name, CONT_NUM AS 'Phone Number', applicant.DL_NUM as 'DL #',
#	 Count(FORM_NUM) as '# of Cars' from applicant inner join form  where applicant.APP_CODE = form.APP_CODE group by applicant.APP_CODE;

#NewAdminHome DELETE
SET FOREIGN_KEY_CHECKS=0; DELETE applicant, account, form, emission, vehicle_info, driver_license from applicant inner join account inner join form inner join emission
	inner join vehicle_info inner join driver_license where driver_license.DL_NUM=applicant.DL_NUM and applicant.APP_CODE=vehicle_info.APP_CODE AND form.APP_CODE=applicant.APP_CODE and vehicle_info.EMM_CODE=emission.EMM_CODE
	AND emission.EMM_CODE=form.EMM_CODE AND applicant.APP_CODE=101 and applicant.USERNAME=account.USERNAME;

#SELECT Count(FORM_NUM) as YN from form inner join applicant where applicant.APP_CODE = form.APP_CODE  group by applicant.APP_CODE;

#usercarhome
#SELECT applicant.APP_CODE, VIN, if (QUALIFICATION=1, 'Yes', 'No') as Qualification, MODEL, MODEL_YEAR, MANUFACTURER, CAR_TYPE, VEH_CLASS, VEH_COLOR, 
#            PLATE_NUM from car_model inner join vehicle_info inner join applicant inner join form inner join emission where applicant.APP_CODE = 100
#            and vehicle_info.APP_CODE=applicant.APP_CODE and vehicle_info.EMM_CODE=emission.EMM_CODE and vehicle_info.CM_CODE = car_model.CM_CODE and form.EMM_CODE = emission.EMM_CODE;
            
#----
*/


                

#SELECT applicant.APP_CODE as 'App #', concat(LAST_NAME,', ',FIRST_NAME) As Name, registrar.BRANCH_LOC AS Branch, DATE_ADD(DATE_REG, INTERVAL 10 year) AS DATE, 
#	if (QUALIFICATION=1, 'Yes', 'No') as Qualification, form.FORM_NUM FROM registration.applicant inner join registration.form inner join registrar 
#    where form.BRANCH_CODE=registrar.BRANCH_CODE and form.APP_CODE = applicant.APP_CODE;
    



    


