﻿create user "STOREAPP" identified by "root";
alter user "STOREAPP" quota unlimited on "USERS";

-- SYSTEM PRIVILEGES
GRANT CREATE ANY INDEX TO "STOREAPP" ;
GRANT ALTER ANY INDEX TO "STOREAPP" ;

GRANT CREATE ANY PROCEDURE TO "STOREAPP" ;
GRANT ALTER ANY PROCEDURE TO "STOREAPP" ;

GRANT CREATE ANY TABLE TO "STOREAPP";
GRANT ALTER ANY TABLE TO "STOREAPP" ;

GRANT CREATE ANY SEQUENCE TO "STOREAPP" ;
GRANT ALTER ANY SEQUENCE TO "STOREAPP" ;

GRANT CREATE ANY TRIGGER TO "STOREAPP" ;
GRANT ALTER ANY TRIGGER TO "STOREAPP" ;
GRANT CREATE SESSION TO "STOREAPP" ;

CREATE TABLE STORE_USER (
    ID NUMBER(10) NOT NULL,
    USERNAME VARCHAR2(50) NOT NULL,
    PASS VARCHAR2(50) NOT NULL,
    
    CONSTRAINT USER_PK PRIMARY KEY (ID)
);

CREATE SEQUENCE SEQ_USER
MINVALUE 0
MAXVALUE 9999999999
START WITH 0
INCREMENT BY 1
NOCACHE;

CREATE OR REPLACE TRIGGER TRIGGER_SEQ_STORE_USER
BEFORE INSERT ON STORE_USER
FOR EACH ROW
BEGIN    
    SELECT SEQ_USER.NEXTVAL
    INTO :NEW.ID
    FROM DUAL;        
END;

grant select, update, insert, delete on store_user to STOREAPP;