import React from "react";
import { CommonTitle } from "../../atoms/CommonTitle";
import { CommonTableHeader } from "../../molecules/CommonTableHeader";
import { CommonTableRow } from "../../molecules/CommonTableRow";
import { CommonButtonPanel, CommonButtonPanelProps } from "../../molecules/CommonButtonPanel";
import { CommonHeadersContainer, CommonRowsContainer, CommonTableContainer, CommonTableTitleContainer} from "./styles";

export type CommonTableProps = {
    title: string;
    columnNames: Array<string>;
    rows: Array<Array<string>>;
    rowHeight: string;
    headersHeight: string;
    buttonPanel?: CommonButtonPanelProps;
    onRowClick?: (row: Array<string>) => void;
}

export const CommonTable: React.FC<CommonTableProps> = (props: CommonTableProps) => {
    return (
        <CommonTableContainer>
            <CommonTableTitleContainer>
                <CommonTitle 
                    text={props.title}/>
            </CommonTableTitleContainer>
            {
                props.buttonPanel === undefined ?
                    undefined
                    :(
                        <CommonButtonPanel buttons={props.buttonPanel.buttons} />
                    )
            }
            <CommonHeadersContainer height={props.headersHeight}>
                <CommonTableHeader 
                    columnNames={props.columnNames}></CommonTableHeader>
            </CommonHeadersContainer>
            <CommonRowsContainer>
                {
                    props.rows.map((row, i) => (
                        <CommonTableRow
                            values={row}
                            containerProps={{ height: props.rowHeight }}
                            key={i}
                            onClick={() => { props.onRowClick && props.onRowClick(row); }}></CommonTableRow>
                    ))
                }
            </CommonRowsContainer>
        </CommonTableContainer>
    )
}