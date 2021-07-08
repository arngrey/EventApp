import React from "react";
import { CommonTitle } from "../../atoms/CommonTitle";
import { TableHeader } from "../../molecules/TableHeader";
import { TableRow } from "../../molecules/TableRow";
import { CommonButtonPanel, CommonButtonPanelProps } from "../../molecules/CommonButtonPanel";
import { HeadersContainer, RowsContainer, TableContainer, TableTitleContainer} from "./styles";

export type TableProps = {
    title: string;
    columnNames: Array<string>;
    rows: Array<Array<string>>;
    rowHeight: string;
    headersHeight: string;
    buttonPanel?: CommonButtonPanelProps;
}

export const Table: React.FC<TableProps> = (props: TableProps) => {
    return (
        <TableContainer>
            <TableTitleContainer>
                <CommonTitle 
                    text={props.title}/>
            </TableTitleContainer>
            {
                props.buttonPanel === undefined ?
                    undefined
                    :(
                        <CommonButtonPanel buttons={props.buttonPanel.buttons} />
                    )
            }
            <HeadersContainer height={props.headersHeight}>
                <TableHeader 
                    columnNames={props.columnNames}></TableHeader>
            </HeadersContainer>
            <RowsContainer>
                {
                    props.rows.map((row, i) => (
                        <TableRow
                            values={row}
                            containerProps={{ height: props.rowHeight }}
                            key={i}></TableRow>
                    ))
                }
            </RowsContainer>
        </TableContainer>
    )
}