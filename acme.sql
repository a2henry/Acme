create schema acme;

go

create table acme.ad (
 ad_id int identity(1,1) primary key,
 ad_name varchar(100) unique,
 ad_content varchar(8000)
)


create table acme.newspaper (
 newspaper_id int identity(1,1) primary key,
 newspaper_name varchar(100) unique,

)

create table acme.ad_newspaper_detail(
  ad_id int,
  newspaper_id int
  CONSTRAINT [PK_ad_newspaper_detail] PRIMARY KEY NONCLUSTERED 
(
	ad_id,
	newspaper_id
), 
  CONSTRAINT [FK_ad_newspaper_detail.ad] FOREIGN KEY(ad_id)
REFERENCES acme.ad ([ad_id]) on delete cascade,
  CONSTRAINT [FK_ad_newspaper_detail.newspaper] FOREIGN KEY(newspaper_id)
REFERENCES acme.newspaper (newspaper_id) on delete cascade
)

insert into acme.newspaper values('NY times')
insert into acme.newspaper values('Time')